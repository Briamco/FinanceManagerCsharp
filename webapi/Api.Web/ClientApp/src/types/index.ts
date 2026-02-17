/**
 * Interfaz que representa una categoría de gasto.
 */
export interface Category {
  /** Identificador único de la categoría */
  id: number
  /** Nombre de la categoría */
  name: string
  /** Presupuesto mensual asignado a la categoría */
  monthBudget: number
}

/**
 * Interfaz que representa un reporte de categoría.
 * Utilizada para mostrar estadísticas de gastos por categoría.
 */
export interface CategoryReport {
  /** Nombre de la categoría */
  categoryName: string
  /** Total gastado en esta categoría */
  total: number
  /** Presupuesto asignado a la categoría */
  budget: number
  /** Porcentaje del total general que representa esta categoría */
  percent: number
}

/**
 * Interfaz que representa un gasto.
 */
export interface Spend {
  /** Identificador único del gasto */
  id: number
  /** Descripción del gasto */
  description: string
  /** Monto del gasto */
  amount: number
  /** Fecha del gasto en formato ISO */
  date: string
  /** Identificador de la categoría asociada */
  categoryId: number
  /** Nombre de la categoría (opcional, se incluye en las respuestas de la API) */
  category?: string
}

/**
 * Interfaz que representa un reporte general de gastos.
 * Incluye el total, el desglose por categorías y las advertencias.
 */
export interface GeneralReport {
  /** Total de todos los gastos */
  total: number
  /** Lista de reportes por categoría */
  categoriesReport: CategoryReport[]
  /** Lista de advertencias (ej: presupuestos excedidos) */
  warnings: string[]
}