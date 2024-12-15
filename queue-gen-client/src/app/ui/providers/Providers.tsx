'use client';

import { theme } from '@/src/shared/ui/theme';
import { ThemeProvider } from '@mui/material';
import { ReactNode } from 'react';

interface IProvidersProps {
    children: ReactNode;
}

const Providers = (props: IProvidersProps) => {
    const { children } = props;

    return <ThemeProvider theme={theme}>{children}</ThemeProvider>;
};

export default Providers;
