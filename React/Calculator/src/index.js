import { createEvent } from '@testing-library/react';
import React, {useState} from 'react';
import ReactDOM from 'react-dom/client';
function App () {
  let [text, SetText] = useState("")
  let CreateEvent = (In) => {
   if(In !== "=" && In !== "C") return (ev) => SetText(text + In)
   else if( In === "C") return (ev) => SetText("")
   else return (ev) => {
    try {
      SetText(eval(text))
    } catch (error) {
      SetText("Error")
    }}
  }
  let Chars = ["C", "√", "%", "/", "7", "8", "9", "*", "4", "5", "6", "-", "1", "2", "3", "+", "0", ".", "="]
  let elems = Chars.map((e) => 
      <button key={e} onClick={CreateEvent(e)} style={e === "+" ? {height:"200px"} : undefined}>{e}</button>
  )
  return (<>
  <h1 className='Output'>{text}</h1>
  <div className='Grid'>{elems}</div>
  </>)
}
const container = document.getElementById("root");
const root = ReactDOM.createRoot(container)
root.render(<App/>)
