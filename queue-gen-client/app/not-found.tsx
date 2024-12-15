'use client';

import { Box, Typography, Button, useTheme } from '@mui/material';
import { useRouter } from 'next/navigation';
import { motion } from 'framer-motion';

const NotFoundPage = () => {
    const router = useRouter();
    const theme = useTheme(); // Получаем текущую тему

    return (
        <Box
            sx={{
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'center',
                alignItems: 'center',
                height: '100vh',
                textAlign: 'center',
                backgroundColor: theme.palette.background.default, // Используем цвет фона из темы
                padding: '16px',
            }}
        >
            <motion.div
                initial={{ opacity: 0, scale: 0.8 }}
                animate={{ opacity: 1, scale: 1 }}
                transition={{ duration: 0.5 }}
            >
                <Typography
                    variant="h1"
                    sx={{
                        fontSize: '8rem',
                        fontWeight: 'bold',
                        color: theme.palette.error.main, // Используем цвет ошибки из темы
                    }}
                >
                    404
                </Typography>
            </motion.div>
            <motion.div
                initial={{ opacity: 0, y: 50 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ delay: 0.3, duration: 0.5 }}
            >
                <Typography
                    variant="h4"
                    sx={{
                        marginBottom: '16px',
                        color: theme.palette.text.primary, // Основной цвет текста
                    }}
                >
                    Page Not Found
                </Typography>
                <Typography
                    variant="body1"
                    sx={{
                        marginBottom: '32px',
                        color: theme.palette.text.secondary, // Второстепенный цвет текста
                    }}
                >
                    Sorry, the page you’re looking for doesn’t exist.
                </Typography>
            </motion.div>
            <motion.div
                initial={{ opacity: 0, y: 50 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ delay: 0.6, duration: 0.5 }}
            >
                <Button
                    variant="contained"
                    color="primary"
                    size="large"
                    onClick={() => router.push('/')}
                    sx={{
                        textTransform: 'none',
                        padding: '12px 24px',
                        fontSize: '1rem',
                        borderRadius: '8px',
                        boxShadow: theme.shadows[3], // Тени из темы
                    }}
                >
                    Back to Home
                </Button>
            </motion.div>
        </Box>
    );
};

export default NotFoundPage;
