import { TodoCard } from './TodoCard';
import { TodoForm } from './TodoForm';
import { useTodo } from '../hooks/useTodo';

export const TodoModule = () => {
  const { todos, addTodo, changeStatusTodo, deleteTodo } = useTodo();
  return (
    <main className="page">
      <div className="container stack">
        <header>
          <h1>Mis tareas</h1>
          <p className="text-muted">
            Organiza tus actividades pendientes.
          </p>
        </header>

        <TodoForm handleAddTodo={addTodo} />

        <section className="stack" aria-labelledby="todo-list-title">
          <h2 id="todo-list-title">Lista de tareas</h2>
          {
            todos.length > 0 ? (
              <div className="grid">
            {
              todos.map((item) => 
              (
                    <TodoCard 
                    item={item}
                    handleStatus={() => changeStatusTodo(item.id)}
                    handleDelete={() => deleteTodo(item.id)}
                    />
              )

              )
            }
            
          </div>
            ) :
            (<h1>No hay tarea</h1>)
          }
          
        </section>
      </div>
    </main>
  );
}
