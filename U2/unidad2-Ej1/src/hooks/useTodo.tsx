import { useReducer } from 'react'
import { type TodoTask } from '../types/TodoTask'
import type { TodoAction } from '../types/TodoAction';

function reducerTodo(state:TodoTask[],action:TodoAction)
{
    switch(action.type)
    {
        case 'ADD':
        {
            return [...state, action.item]
        }
        case 'STATUS':
        {

            return state.map((item) => item.id === action.id 
            ? {...item, isCompleted: !item.isCompleted} : item
            )
        }
        case 'DELETE':
        {
            return state.filter(item => item.id !== action.id)
        }
        case 'UPDATE':
        {
            return state.map((item) => item.id === action.id
            ? {...item, isCompleted: !item.isCompleted} : item
            )
        }
    }
}
export const useTodo = () => {
    const [todos,dispatchTodo] = useReducer(reducerTodo,[]) 

    function addTodo(title:string, description:string)
    {
        dispatchTodo({type:'ADD', item:{id: crypto.randomUUID(), title, description, isCompleted:false}})
    }
    
      function changeStatusTodo(id:string)
    {
        dispatchTodo({type:'STATUS', id})
    }

    function deleteTodo(id:string)
    {
        dispatchTodo({type:'DELETE', id})
    }

    function updateTodo(id:string)
    {
        dispatchTodo({type:'UPDATE', id})
    }

  return {
    todos,
    addTodo,
    changeStatusTodo,
    deleteTodo,
    updateTodo
  }
}
