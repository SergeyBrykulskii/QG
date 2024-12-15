'use client';

import { useParams } from 'next/navigation';
import { Button, Card, CardContent, Typography } from '@mui/material';

const mockDisciplines = [
    { id: 1, name: 'Math' },
    { id: 2, name: 'Physics' },
];

const GroupDisciplinesPage = () => {
    const params = useParams();
    const { groupId } = params;

    return (
        <div>
            <Typography variant="h4" gutterBottom>
                Disciplines for Group {groupId}
            </Typography>
            <div style={{ display: 'flex', gap: '16px', flexWrap: 'wrap' }}>
                {mockDisciplines.map((subject) => (
                    <Card key={subject.id} sx={{ minWidth: 275 }}>
                        <CardContent>
                            <Typography variant="h5">{subject.name}</Typography>
                            <Button
                                href={`/groups/${groupId}/disciplines/${subject.id}`}
                            >
                                View Queue
                            </Button>
                        </CardContent>
                    </Card>
                ))}
            </div>
        </div>
    );
};

export default GroupDisciplinesPage;
