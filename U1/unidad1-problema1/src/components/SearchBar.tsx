import { useState, type FormEvent } from 'react';
import '../styles/SearchBar.css';

interface SearchBarProps {
  onSearch: (term: string) => void;
}

export function SearchBar({ onSearch }: SearchBarProps) {
  const [inputValue, setInputValue] = useState('');

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault();
    if (!inputValue.trim()) return;

    onSearch(inputValue);
    setInputValue('');
  };

  return (
    <form className="search-bar" onSubmit={handleSubmit}>
      <label className="search-bar__label" htmlFor="gif-search">
        Buscar GIFs
      </label>
      <div className="search-bar__controls">
        <input
          id="gif-search"
          className="search-bar__input"
          type="search"
          name="query"
          placeholder="Escribe un término, por ejemplo: transformers"
          value={inputValue}
          onChange={(e) => setInputValue(e.target.value)}
        />
        <button className="search-bar__button" type="submit">
          Buscar
        </button>
      </div>
    </form>
  );
}