import { createTheme } from '@mui/material/styles';

export const theme = createTheme({
    palette: {
        mode: 'dark', // Устанавливаем тёмный режим
        primary: {
            main: '#1976d2', // Основной синий (акцентный)
        },
        secondary: {
            main: '#03DAC6', // Мягкий бирюзовый для второстепенных акцентов
        },
        background: {
            default: '#121212', // Глубокий чёрный/серый фон
            paper: '#1e1e1e', // Фон для карточек и элементов
        },
        text: {
            primary: '#ffffff', // Белый для основного текста
            secondary: '#b0bec5', // Светло-серый для второстепенного текста
        },
    },
    typography: {
        fontFamily: '"Roboto", "Helvetica", "Arial", sans-serif', // Стандартный шрифт MUI
        h1: {
            fontWeight: 700,
            fontSize: '2.5rem',
            color: '#ffffff',
        },
        h2: {
            fontWeight: 600,
            fontSize: '2rem',
            color: '#ffffff',
        },
        body1: {
            fontSize: '1rem',
            color: '#b0bec5', // Второстепенный текст
        },
        body2: {
            fontSize: '0.875rem',
            color: '#90a4ae', // Ещё светлее для сносок
        },
    },
});
