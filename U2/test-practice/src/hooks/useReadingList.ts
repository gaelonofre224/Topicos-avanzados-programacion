import { useActionState, useRef, useState } from 'react';
import type { ReadingListItem } from '../types/bookItem';

const initialState: ReadingListItem[] = [{
    id: crypto.randomUUID(),
    title: 'Project Hail Mary',
    author: 'Andy Weir',
    pages: 496
}, {
    id: crypto.randomUUID(),
    title: 'Circe',
    author: 'Madeline Miller',
    pages: 400
}, { 
    id: crypto.randomUUID(),
    title: 'The Seven Husbands of Evelyn Hugo',
    author: 'Taylor Jenkins Reid',
    pages: 400
}];
const [readingList, setReadingList] = useState<ReadingListItem[]>(initialState);

const useReadingList = () => {
    const inputBookTitleRef = useRef<HTMLInputElement | null>(null);

    const ReadingListAction = async (prevState: ReadingListItem[], formData: FormData): Promise<ReadingListItem[]> => {
        await new Promise((resolve) => setTimeout(resolve, 3000));
        inputBookTitleRef.current?.focus();
        return [
            ...prevState,
            {
                id: crypto.randomUUID(),
                title: formData.get('title') as string,
                author: formData.get('author') as string,
                pages: Number(formData.get('pages'))
            }
        ];
    };

    const [readingList, readingListAction, isLoadedAction] = useActionState(ReadingListAction, initialState);

    return { 
        readingList, 
        readingListAction, 
        isLoadedAction,
        inputBookTitleRef 
    };
};

export default useReadingList;
