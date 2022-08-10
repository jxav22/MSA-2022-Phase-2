import axios from "axios";
import { useState } from 'react';
import './App.css';

function App() {
  // Declare a new state variable, which we'll call "word"
  const [word, setWord] = useState("");
  const [wordInfo, setWordInfo] = useState<undefined | any>(undefined);

  const DICTIONARY_BASE_URL = "https://api.dictionaryapi.dev/api/v2/entries/en";
  return (
    <div>
      <h1>
        DICTIONARY DEFINITIONS
      </h1>
      
      <div>
        <input 
          type="text" 
          id="word-to-search" 
          name="word-to-search" 
          defaultValue="ENTER A WORD" 
          onChange={e => setWord(e.target.value)}
        />
        <button onClick={search}>
        Search
        </button>
      </div>

      <p>
        You have entered {word}
      </p>

      <div id="dictionary-definition">{wordInfo[0].meanings[0].definitions[0].definition}</div>
    </div>
  );

  function search() {
    console.log("Started search");
    axios.get(DICTIONARY_BASE_URL + "/" + word).then((res) => {
      setWordInfo(res.data);
    });
    console.log(wordInfo[0].meanings[0].definitions[0].definition);
  }
}

export default App;