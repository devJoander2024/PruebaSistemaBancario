export class GenericResponseDto<T> {
    status: number;
    title: string;
    message: string;
    data: T;
  }
  