import { useState } from 'react';

export const useSearch = () => {
  const [searchTerm, setSearchTerm] = useState('cats');
  const [history, setHistory] = useState<string[]>(['cats']);

  const onSearch = (query: string) => {
    const cleanQuery = query.trim();
    if (!cleanQuery) return;

    setSearchTerm(cleanQuery);


    const exists = history.some(
      (item) => item.toLowerCase() === cleanQuery.toLowerCase()
    );

    if (!exists) {
      setHistory([cleanQuery, ...history]);
    }
  };

  return {
    searchTerm,
    history,
    onSearch,
  };
};