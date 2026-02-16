import { apiService } from "../services/apiService"

const CreateCategory = () => {
  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    const formData = new FormData(e.currentTarget)
    const name = formData.get('cat-name') as string
    const budget = parseFloat(formData.get('cat-budget') as string)

    apiService.addCategory({ name, monthBudget: budget })
      .then(() => {
        alert('Categoría añadida con éxito')
        e.currentTarget.reset()
      })
      .catch(err => alert('Error al añadir categoría: ' + err.message))
  }

  return (
    <section className="bg-white p-6 rounded-xl shadow-sm border">
      <h2 className="text-lg font-bold mb-4">Gestión de Categorías</h2>
      <form onSubmit={handleSubmit} id="form-category" className="space-y-3">
        <input type="text" id="cat-name" placeholder="Nombre" className="w-full p-2 border rounded" required />
        <input type="number" id="cat-budget" placeholder="Presupuesto" className="w-full p-2 border rounded" required />
        <button type="submit" className="w-full bg-slate-800 text-white py-2 rounded">Añadir Categoría</button>
      </form>
    </section>
  )
}

export default CreateCategory