import '../styles/SearchChip.css';

interface SearchChipProps {
  term: string;
  isActive: boolean;
  onSelect: (term: string) => void;
}

export function SearchChip({ term, isActive, onSelect }: SearchChipProps) {
  const activeClass = isActive ? ' search-chip--active' : '';

  return (
    <button
      className={`search-chip${activeClass}`}
      type="button"
      onClick={() => onSelect(term)}
    >
      {term}
    </button>
  );
}