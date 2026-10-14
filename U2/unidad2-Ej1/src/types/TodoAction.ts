import type { TodoTask } from './TodoTask'

export type TodoAction =
  | { type: 'ADD'; item: TodoTask }
  | { type: 'STATUS'; id: string }
  | { type: 'DELETE'; id: string }
  | { type: 'UPDATE'; id: string;}