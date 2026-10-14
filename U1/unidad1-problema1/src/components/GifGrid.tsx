import '../styles/GifGrid.css';
import type { GifReference } from '../types/gifsTypes';
import { GifCard } from './GifCard.tsx';

interface GifGridProps {
  gifs: GifReference[];
}

export function GifGrid({ gifs }: GifGridProps) {
  return (
    <ul className="gif-grid">
      {gifs.map((gif) => (
        <li key={gif.id}>
          <GifCard gif={gif} />
        </li>
      ))}
    </ul>
  );
}