'use server';

import { Button, Card, CardContent, Typography } from '@mui/material';
import Link from 'next/link';

const mockGroups = [
    { id: 1, name: 'Group A' },
    { id: 2, name: 'Group B' },
];

const Groups = () => {
    return (
        <div>
            <Typography variant="h4" gutterBottom>
                Groups
            </Typography>
            <div style={{ display: 'flex', gap: '16px', flexWrap: 'wrap' }}>
                {mockGroups.map((group) => (
                    <Card key={group.id} sx={{ minWidth: 275 }}>
                        <CardContent>
                            <Typography variant="h5">{group.name}</Typography>
                            <Button
                                component={Link}
                                href={`/groups/${group.id}`}
                            >
                                View Subjects
                            </Button>
                        </CardContent>
                    </Card>
                ))}
            </div>
            <Button
                variant="contained"
                color="primary"
                style={{ marginTop: '16px' }}
            >
                Add Group
            </Button>
        </div>
    );
};

export default Groups;
