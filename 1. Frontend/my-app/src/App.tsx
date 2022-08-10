import { useState } from 'react';
import './App.css';

function App() {
  // Declare a new state variable, which we'll call "word"
  const [word, setWord] = useState("");

  return (
    <div>
      <h1>
        DICTIONARY DEFINITIONS
      </h1>
      
      <div>
        <input type="text" id="pokemon-name" name="pokemon-name" defaultValue="ENTER A WORD" onChange={e => setWord(e.target.value)}/>
        <button onClick={search}>
        Search
        </button>
      </div>

      <p>
        You have entered {word}
      </p>
    </div>
  );

  function search(){
      alert("Search button has been clicked!");
  }
}

export default App;