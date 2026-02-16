import { useEffect, useState } from "react"
import { apiService } from "../services/apiService"
import type { Category } from "../types"

const CreateSpend = () => {
  const [categories, setCategories] = useState<Category[]>([])
  const [loading, setLoading] = useState(true);


  useEffect(() => {
    apiService.getCategory()
      .then(setCategories)
      .catch(err => alert('Error al cargar categorías: ' + err.message))
      .finally(() => setLoading(false))
  }, [])

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    const formData = new FormData(e.currentTarget)
    const description = formData.get('spend-desc') as string
    const amount = parseFloat(formData.get('spend-amount') as string)
    const categoryId = parseInt(formData.get('spend-cat') as string)
    const date = formData.get('spend-date') as string

    apiService.addSpend({ description, amount, categoryId, date: new Date(date) })
      .then(() => {
        alert('Gasto registrado con éxito')
        e.currentTarget.reset()
      })
      .catch(err => alert('Error al registrar gasto: ' + err.message))
  }

  if (loading) return <div>Cargando categorías...</div>;

  return (
    <section className="bg-white p-6 rounded-xl shadow-sm border">
      <h2 className="text-lg font-bold mb-4">Registrar Gasto</h2>
      <form onSubmit={handleSubmit} id="form-spend" className="space-y-3">
        <input type="text" id="spend-desc" placeholder="Descripción" className="w-full p-2 border rounded" required />
        <input type="number" id="spend-amount" placeholder="Monto" className="w-full p-2 border rounded" required />
        <select id="spend-cat" className="w-full p-2 border rounded" required>
          {categories.map(c => (
            <option key={c.id} value={c.id}>{c.name}</option>
          ))}
        </select>
        <input type="date" id="spend-date" className="w-full p-2 border rounded" required />
        <button type="submit" className="w-full bg-blue-600 text-white py-2 rounded">Guardar Gasto</button>
      </form>
    </section>
  )
}

export default CreateSpend;