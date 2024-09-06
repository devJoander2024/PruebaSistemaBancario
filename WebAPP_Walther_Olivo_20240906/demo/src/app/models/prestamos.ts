import { TipoPrestamo } from "./tipoprestamo";

// prestamo.model.ts
export class Prestamo {
    prestamoId: number;
    descripcion: string;
    cantidad: number;
    estado: string;
    tipoPrestamoId: number;  // Foreign Key ID for TipoPrestamo
  
    // This will hold the full TipoPrestamo object if needed
    tipoPrestamo: TipoPrestamo | null;
  }
  