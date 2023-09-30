local per = {} 
local Coords = {} 
Coords["industrialforegoing:plant_gatherer_1"] = "-537_67_-519"
Coords["sophisticatedstorage:limited_barrel_0"] = "-541_67_-521"
local   ws = http.websocket("ws://localhost:8080")
count = 0
function HasColen(str) 
 for i = string.len(str),1,-1 do
  if string.sub(str, i, i) == ":" then
   return true
  end 
 end
 return str 
end

function ParseTanks(tab)
 str = "[" -- the retrn val
 if #tab == 0 then return str end
 for i, j in pairs(tab) do
  str = str .. j.amount
  if i ~= #tab then
   str = str .. ","
  end
 end 
 return str .. "]"
end
function ParseItems(tab) 
 str = 0
 for i, j in pairs(tab) do
  str = str + j.count
 end 
 return tostring(str)
end 





for i, j in pairs(Coords) do 
 per[i] = {
  Item=false,
  Fluid=false,
  Energy=false, 
  Per=peripheral.wrap(i)
 } 
 types = table.pack(peripheral.getType(i))
 
 for i1=1,#types do
  if types[i1] == "inventory" then 
   per[i].Item = true 
  elseif types[i1] == "fluid_storage" then
   per[i]. Fluid = true
  elseif types[i1] == "energy_storage" then
   per[i].Energy = true
  else
   --Todo, add custom operations
  end
  end
 end
 ws.send(i .. " " .. j)  
end   
ws.send("Done")   
sleep(1)
while true do
 sleep(1) 
 data = "{"
 count = -1
 for i, j in pairs(per) do
  data = data .. '"' .. i .. '":{'
  if j.Fluid == true then
   data = data .. '"tanks": '.. ParseTanks(j.Per.tanks() )
  end    
  if j.Item == true then 
   if j.Fluid == true then data = data .. ',' end
   data = data .. '"Items":'   
   data = data .. ParseItems(j.Per.list())
  end
  if j.Energy then 
   data = data .. ',"Energy":' .. j.Per.getEnergy() 
  end
  data = data .. "}" 
  if(count ~= #per) then  data = data .. "," end
  count = count + 1
 end
 ws.send(data  .. "}")
end

 
