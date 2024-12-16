const BASE_API_URL = process.env.NEXT_PUBLIC_API_URL;

export const buildApiUrl = <
  TQueryParams extends Record<string, string | number | boolean | undefined>
>(
  routeParts: (string | number | undefined)[],
  queryParams?: TQueryParams
): string => {
  // Формируем путь из массива частей, убирая undefined
  const path = routeParts.filter(Boolean).join('/');

  // Базовый URL с добавленным путем
  const url = new URL(`${BASE_API_URL}/${path}`);

  // Добавляем query-параметры, если они есть
  if (queryParams) {
    Object.entries(queryParams).forEach(([key, value]) => {
      if (value !== undefined) {
        url.searchParams.append(key, String(value));
      }
    });
  }

  return url.toString();
};
