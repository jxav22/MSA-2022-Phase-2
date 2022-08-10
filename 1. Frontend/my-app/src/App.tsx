import axios from "axios";
import { useState } from 'react';
import './App.css';

import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';

import {
  createTheme,
  responsiveFontSizes,
  ThemeProvider,
} from '@mui/material/styles';
import Typography from '@mui/material/Typography';

let theme = createTheme();
theme = responsiveFontSizes(theme);

function App() {
  // Declare a new state variable, which we'll call "word"
  const [word, setWord] = useState("");
  const [wordInfo, setWordInfo] = useState<undefined | any>(undefined);
  const [definition, setDefinition] = useState("");

  const DICTIONARY_BASE_URL = "https://api.dictionaryapi.dev/api/v2/entries/en";

  return (
    <div className="main">
      <ThemeProvider theme={theme}>
        <Typography variant="h2">DICTIONARY, DEFINITIONS</Typography>
      </ThemeProvider>

      <TextField
        id="outlined-search"
        label="ENTER A WORD"
        type="search"
        variant="filled"
        onChange={e => setWord(e.target.value)}
      />

      <Button onClick={search} variant="contained">
        Define
      </Button>

      <ThemeProvider theme={theme}>
        <Typography variant="h5">{definition}</Typography>
      </ThemeProvider>
    </div>
  );

  function search() {
    axios.get(DICTIONARY_BASE_URL + "/" + word).then((res) => {
      setWordInfo(res.data);
      setDefinition(res.data[0].meanings[0].definitions[0].definition);
    });
  }
}

export default App;