import '../styles/SearchHistory.css';
import { SearchChip } from './SearchChip.tsx';

interface SearchHistoryProps {
  history: string[];
  activeTerm: string;
  onSelectChip: (term: string) => void;
}

export function SearchHistory({
  history,
  activeTerm,
  onSelectChip,
}: SearchHistoryProps) {
  return (
    <section className="search-history" aria-label="Búsquedas realizadas">
      <h2 className="search-history__title">Búsquedas</h2>
      <ul className="search-history__list">
        {history.map((term) => (
          <li key={term}>
            <SearchChip
              term={term}
              isActive={term.toLowerCase() === activeTerm.toLowerCase()}
              onSelect={onSelectChip}
            />
          </li>
        ))}
      </ul>
    </section>
  );
}