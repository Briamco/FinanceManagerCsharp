import { useRef, useState } from "react"
import { apiService } from "../services/apiService"

/**
 * Props del componente CreateCategory.
 */
interface Props {
  /** Callback que se ejecuta después de guardar una categoría exitosamente */
  onSaved: () => void
}

/**
 * Componente para crear nuevas categorías.
 * Muestra un formulario con campos para el nombre y presupuesto mensual.
 * Valida que no existan categorías duplicadas a través de la API.
 * 
 * @param props - Props del componente
 */
const CreateCategory = ({ onSaved }: Props) => {
  const formRef = useRef<HTMLFormElement>(null);

  const [name, setName] = useState<string>('')
  const [budget, setBudget] = useState<number>(0)

  /**
   * Maneja el envío del formulario.
   * Llama a la API para crear la categoría y refresca los datos.
   */
  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    console.log({ name, monthBudget: budget })
    apiService.addCategory({ name, monthBudget: budget })
      .then(() => {
        onSaved()
        alert('Categoría añadida con éxito')
        formRef.current?.reset()
      })
      .catch(err => alert('Error al añadir categoría: ' + err.message))

  }

  return (
    <section className="bg-white p-6 rounded-xl shadow-sm border">
      <h2 className="text-lg font-bold mb-4">Gestión de Categorías</h2>
      <form ref={formRef} onSubmit={handleSubmit} id="form-category" className="space-y-3">
        <input type="text" onChange={(e) => setName(e.target.value)} placeholder="Nombre" className="w-full p-2 border rounded" required />
        <input type="number" onChange={(e) => setBudget(parseFloat(e.target.value))} placeholder="Presupuesto" className="w-full p-2 border rounded" required />
        <button type="submit" className="w-full bg-slate-800 text-white py-2 rounded">Añadir Categoría</button>
      </form>
    </section>
  )
}

export default CreateCategory