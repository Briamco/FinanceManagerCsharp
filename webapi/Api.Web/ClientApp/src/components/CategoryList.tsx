import { apiService } from "../services/apiService";
import type { Category } from "../types";

interface Props {
  categories: Category[]
  onSaved: () => void
}

const CategoryList = ({ categories, onSaved }: Props) => {

  const handleEdit = (id: number) => {
    const category = categories.find(c => c.id === id);
    if (!category) return;

    const newName = prompt('Nuevo nombre de la categoría:', category.name);
    if (newName === null) return; // Cancelado

    const newBudgetStr = prompt('Nuevo presupuesto mensual:', category.monthBudget.toString());
    if (newBudgetStr === null) return; // Cancelado

    const newBudget = parseFloat(newBudgetStr);
    if (isNaN(newBudget)) {
      alert('Presupuesto inválido. Por favor, ingresa un número.');
      return;
    }

    try {
      apiService.updateCategory(id, { name: newName, monthBudget: newBudget });
      onSaved();
    } catch (error) {
      console.error('Error al actualizar la categoría:', error);
      alert('Ocurrió un error al actualizar la categoría. Por favor, intenta nuevamente.');
    }

  }

  const handleDelete = (id: number) => {
    if (window.confirm('¿Estás seguro de que deseas eliminar esta categoría?')) {
      try {
        apiService.deleteCategory(id);
        onSaved();
      } catch (error) {
        console.error('Error al eliminar la categoría:', error);
        alert('Ocurrió un error al eliminar la categoría. Por favor, intenta nuevamente.');
        return;
      }
    }
  }

  return (
    <section className="bg-white p-6 rounded-xl shadow-sm border">
      <div className="flex flex-wrap justify-between items-center mb-6 gap-4">
        <h2 className="text-xl font-bold">Lista de Categorias</h2>
      </div>

      <ul id="list-spends" className="divide-y divide-slate-100">
        {categories.map(c => (
          <li key={c.id} className="py-3 flex justify-between items-center">
            <div>
              <p className="font-medium text-slate-800">{c.name}</p>
              <p className="text-xs text-slate-400">Presupuesto Mensual:</p>
              <p className="text-xs text-slate-400">${c.monthBudget.toLocaleString()}</p>
            </div>
            <div className="flex flex-col items-end gap-2">
              <button onClick={() => handleEdit(c.id)} className="bg-slate-200 transition-all hover:bg-slate-50 cursor-pointer px-2 py-1 rounded text-xs border">✏️ Editar</button>
              <button onClick={() => handleDelete(c.id)} className="bg-red-100 transition-all hover:bg-red-50 cursor-pointer px-2 py-1 rounded text-xs border ml-2">🗑️ Eliminar</button>
            </div>
          </li>
        ))}
      </ul>
    </section>
  )
}

export default CategoryList;