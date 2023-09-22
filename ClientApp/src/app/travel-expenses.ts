// This interface defines the structure of a TravelExpensesDTO object.
export interface TravelExpensesDTO {
  id?: number;
  ref_number: string;
  title_en: string;
  purpose_en: string;
  start_date: string;
  end_date: string;
  airfare: number;
  other_transport: number;
  meals: number;
  other_expenses: number;
  total: number;
}
