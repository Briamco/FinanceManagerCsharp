import { Doughnut } from 'react-chartjs-2';
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js';

ChartJS.register(ArcElement, Tooltip, Legend);

interface Props {
  spended: number;
  budget: number;
  name: string;
}

const BudgetGauge = ({ spended, budget, name }: Props) => {
  const restante = budget - spended;
  const excedido = restante < 0;

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
      <div className="relative h-40 flex justify-center">
        <Doughnut data={data} options={{ cutout: '80%', plugins: { legend: { display: false } } }} />
        <div className="absolute inset-0 flex flex-col items-center justify-end pb-4">
          <span className={`text-xl font-bold ${excedido ? 'text-red-600' : 'text-slate-800'}`}>
            ${spended.toLocaleString()}
          </span>
          <span className="text-xs text-slate-400">de ${budget.toLocaleString()}</span>
        </div>
      </div>
      {excedido && (
        <p className="text-xs text-red-500 font-bold mt-2 animate-pulse">
          ⚠️ ¡Presupuesto Excedido por ${(spended - budget).toLocaleString()}!
        </p>
      )}
    </div>
  );
};

export default BudgetGauge;