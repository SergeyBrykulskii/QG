import { AppBar, Toolbar, Typography, Button } from '@mui/material';
import Link from 'next/link';

const Header = () => {
    return (
        <AppBar position="static">
            <Toolbar>
                <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                    QueueGen
                </Typography>
                <Button color="inherit" component={Link} href="/groups">
                    Groups
                </Button>
                <Button color="inherit" component={Link} href="/profile">
                    Profile
                </Button>
            </Toolbar>
        </AppBar>
    );
};

export default Header;
