import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js';
import { Pie } from 'react-chartjs-2';
import type { CategoryReport } from '../types';

// Registrar elementos necesarios para Chart.js
ChartJS.register(ArcElement, Tooltip, Legend);

/**
 * Props del componente CategoryPieChart.
 */
interface Props {
  /** Datos de reportes por categoría para mostrar en el gráfico */
  data: CategoryReport[];
}

/**
 * Componente que muestra un gráfico de pastel (Pie Chart).
 * Visualiza la distribución de gastos por categoría de forma gráfica.
 * Utiliza Chart.js y react-chartjs-2 para el renderizado.
 * 
 * @param props - Props del componente
 */
const CategoryPieChart = ({ data }: Props) => {
  // Preparar datos para el gráfico
  const chartData = {
    labels: data.map(c => c.categoryName),
    datasets: [
      {
        label: 'Gastos por Categoría',
        data: data.map(c => c.total),
        backgroundColor: [
          'rgba(54, 162, 235, 0.6)',   // Azul
          'rgba(255, 99, 132, 0.6)',   // Rojo
          'rgba(255, 206, 86, 0.6)',   // Amarillo
          'rgba(75, 192, 192, 0.6)',   // Verde
          'rgba(153, 102, 255, 0.6)',  // Morado
          'rgba(255, 159, 64, 0.6)',   // Naranja
        ],
        borderColor: [
          'rgba(54, 162, 235, 1)',
          'rgba(255, 99, 132, 1)',
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
          'rgba(153, 102, 255, 1)',
          'rgba(255, 159, 64, 1)',
        ],
        borderWidth: 1,
      },
    ],
  };

  // Opciones de configuración del gráfico
  const options = {
    responsive: true,
    plugins: {
      legend: {
        position: 'bottom' as const,
      },
    },
  };

  return (
    <div className="bg-white col-span-2 p-4 rounded-xl shadow-sm border flex flex-col items-center">
      <h3 className="font-bold text-slate-700 mb-4">Distribución de Gastos - Mensual</h3>
      <div className="w-full max-w-75">
        <Pie data={chartData} options={options} />
      </div>
    </div>
  );
};

export default CategoryPieChart;