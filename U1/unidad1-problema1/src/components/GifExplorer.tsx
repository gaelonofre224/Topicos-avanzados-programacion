import '../styles/GifExplorer.css';
import { useSearch } from '../hooks/useSearch.tsx';
import { useGifs } from '../hooks/useGifs.tsx';
import { GifGrid } from './GifGrid.tsx';
import { SearchBar } from './SearchBar.tsx';
import { SearchHistory } from './SearchHistory.tsx';

export function GifExplorer() {
  const { searchTerm, history, onSearch } = useSearch();
  const { gifs } = useGifs(searchTerm);

  return (
    <main className="gif-explorer">
      <header className="gif-explorer__header">
        <p className="gif-explorer__kicker">Giphy</p>
        <h1>Buscador de GIFs</h1>
        <p className="gif-explorer__subtitle">
          Escribe un término, revisa los resultados y conserva cada búsqueda.
        </p>
      </header>

      <SearchBar onSearch={onSearch} />
      <SearchHistory
        history={history}
        activeTerm={searchTerm}
        onSelectChip={onSearch}
      />

      <section className="gif-explorer__results" aria-label="Resultados">
        <div className="gif-explorer__results-header">
          <h2>Resultados para «{searchTerm}»</h2>
          <p>{gifs.length} GIFs</p>
        </div>
        <GifGrid gifs={gifs} />
      </section>
    </main>
  );
}