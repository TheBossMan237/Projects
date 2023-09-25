>## Basin
>>### `getFilter()`
>>
>>#### `returns` 
>>```
>>{
>>  name:<String>- the type of filter
>>  maxStackSize:<int> - the maxiumum amount of 1 item that is allowed 
>>  tags:<Array> - N/A
>>  count:<int> - the number of filters there are
>>  //This is the case if its an attribute filter
>>  nbt : {
>>      MatchedAttribuites : {
>>          Index<int> :  { 
>>              Inverted<int> - if the filter at Index was added as oppisite then it will return 1 otherwise 0,
>>              <string> : string could be anything and will hold the property inside 
>>          }     
>>      }
>>      WhitelistMode<int> - 0: Allow All, 1- Allow List 2 - Deny List
>>} 
>>
>>
>>
>>
>>  //this is the case if its a normal filter
>>  nbt: {
>>      Items:{
>>          Items<ItemsList> - a table of the items, 0 indexed and the values are the nbt data of slot in the filter
>>          Size:<Int> - the amount of slots in the filter (18 dont know why this is here)
>>
>>
>>      }
>>  }
>>  displayName:<String> - the name that is displayed in the minecraft hotbar
>>}
>>```
>>
>
>>### `getInputFluids()`
>>- Returns the fluids that are in the basin
>>
>>#### `Returns`
>>``` 
>>{
>>    {
>>      amount:<int>,
>>      fluid:<string>
>>    },
>>    {
>>      amount:<int>,
>>      fluid:<string>,
>>    }
>>}
>>``` 
>
>>### `getInventory()`
>>```
>>{
>>  Index<int> : {
>>            
>>
>>
>>
>>  }
>>}
>>```
>
>>### `getOutputFluids`
>>```
>>
>>
>>
>>
>>

>>```
