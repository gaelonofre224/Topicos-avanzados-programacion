import { useState, useEffect } from 'react';
import type { GifReference, GiphyItem } from '../types/gifsTypes';

export const useGifs = (query: string) => {
  const [gifs, setGifs] = useState<GifReference[]>([]);
  const [hasError, setHasError] = useState(false);

  useEffect(() => {
    if (!query.trim()) return;

    const getGifs = async () => {
      setHasError(false);
            try {
              const apiKey = import.meta.env.VITE_GIPHY_API_KEY;
              const url = `https://api.giphy.com/v1/gifs/search?api_key=${apiKey}&q=${query}`;

              const response = await fetch(url);
              if (!response.ok) {
                throw new Error('Error al consultar la api');
              }

              const { data } = await response.json();

      const gifsData: GifReference[] = data.map((item: GiphyItem) => ({
        id: item.id,
        title: item.title,
        url: item.images.downsized_medium.url,
        username: `@${item.username}`,
      }));

              setGifs(gifsData);
        } 
      catch (error) 
        {
          console.error(error);
          setHasError(true);
        }
    };

    void getGifs();
  }, [query]);

  return {
    gifs,
    hasError,
  };
};