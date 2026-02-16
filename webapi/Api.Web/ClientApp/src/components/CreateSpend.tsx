import { useRef, useState } from "react"
import { apiService } from "../services/apiService"
import type { Category } from "../types"

interface Props {
  categories: Category[]
  onSaved: () => void
}

const CreateSpend = ({ categories, onSaved }: Props) => {
  const formRef = useRef<HTMLFormElement>(null);

  const [description, setDescription] = useState<string>('')
  const [amount, setAmount] = useState<number>(0)
  const [categoryId, setCategoryId] = useState<number>(0)
  const [date, setDate] = useState<string>('')

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    const dateValid = date ? date : new Date().toISOString().split('T')[0]

    apiService.addSpend({ description, amount, categoryId, date: dateValid })
      .then(() => {
        onSaved()
        alert('Gasto registrado con éxito')
        formRef.current?.reset()
      })
      .catch(err => alert('Error al registrar gasto: ' + err.message))
  }

  return (
    <section className="bg-white p-6 rounded-xl shadow-sm border">
      <h2 className="text-lg font-bold mb-4">Registrar Gasto</h2>
      <form ref={formRef} onSubmit={handleSubmit} id="form-spend" className="space-y-3">
        <input type="text" onChange={(e) => setDescription(e.target.value)} id="spend-desc" placeholder="Descripción" className="w-full p-2 border rounded" required />
        <input type="number" onChange={(e) => setAmount(parseFloat(e.target.value))} id="spend-amount" placeholder="Monto" className="w-full p-2 border rounded" required />
        <select onChange={(e) => setCategoryId(Number(e.target.value))} id="spend-cat" className="w-full p-2 border rounded" required>
          <option value="">Seleccione Categoría</option>
          {categories.map(c => (
            <option key={c.id} value={c.id}>{c.name}</option>
          ))}
        </select>
        <input onChange={(e) => setDate(e.target.value)} type="date" id="spend-date" className="w-full p-2 border rounded" />
        <button type="submit" className="w-full bg-blue-600 text-white py-2 rounded">Guardar Gasto</button>
      </form>
    </section>
  )
}

export default CreateSpend;