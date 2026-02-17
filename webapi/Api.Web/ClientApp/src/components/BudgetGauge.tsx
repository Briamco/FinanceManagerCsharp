import { Doughnut } from 'react-chartjs-2';
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js';

// Registrar elementos necesarios para Chart.js
ChartJS.register(ArcElement, Tooltip, Legend);

/**
 * Props del componente BudgetGauge.
 */
interface Props {
  /** Monto gastado en la categoría */
  spended: number;
  /** Presupuesto asignado a la categoría */
  budget: number;
  /** Nombre de la categoría */
  name: string;
}

/**
 * Componente que muestra un medidor de presupuesto tipo gauge (semi-círculo).
 * Visualiza el progreso del gasto respecto al presupuesto de una categoría.
 * Cambia de color a rojo si se excede el presupuesto.
 * 
 * @param props - Props del componente
 */
const BudgetGauge = ({ spended, budget, name }: Props) => {
  const restante = budget - spended;
  const excedido = restante < 0;

  // Configuración de datos para el gráfico tipo donut (semi-círculo)
  const data = {
    labels: ['Gastado', 'Restante'],
    datasets: [
      {
        // Si se excedió, mostramos todo en rojo, si no, mostramos la división
        data: excedido ? [spended, 0] : [spended, restante],
        backgroundColor: excedido
          ? ['rgba(239, 68, 68, 0.8)', 'rgba(239, 68, 68, 0.1)'] // Rojo si se pasó
          : ['rgba(59, 130, 246, 0.8)', 'rgba(226, 232, 240, 1)'], // Azul y Gris
        hoverOffset: 4,
        borderWidth: 0,
        circumference: 180, // Medio círculo para efecto "medidor"
        rotation: 270,
      },
    ],
  };

  return (
    <div className="bg-white p-4 rounded-xl shadow-sm border text-center">
      <h4 className="text-sm font-semibold text-slate-500 uppercase">{name}</h4>
      {/* Contenedor del gráfico */}
      <div className="relative h-40 flex justify-center">
        <Doughnut data={data} options={{ cutout: '80%', plugins: { legend: { display: false } } }} />
        {/* Texto central con el monto */}
        <div className="absolute inset-0 flex flex-col items-center justify-end pb-4">
          <span className={`text-xl font-bold ${excedido ? 'text-red-600' : 'text-slate-800'}`}>
            ${spended.toLocaleString()}
          </span>
          <span className="text-xs text-slate-400">de ${budget.toLocaleString()}</span>
        </div>
      </div>
      {/* Alerta si se excedió el presupuesto */}
      {excedido && (
        <p className="text-xs text-red-500 font-bold mt-2 animate-pulse">
          ⚠️ ¡Presupuesto Excedido por ${(spended - budget).toLocaleString()}!
        </p>
      )}
    </div>
  );
};

export default BudgetGauge;