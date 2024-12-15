import { getServerSession } from 'next-auth';
import { authOptions } from '@/lib/auth/auth';

export default async function ProtectedPage() {
    const session = await getServerSession(authOptions);

    if (!session) {
        return <p>You are not authorized to view this page.</p>;
    }

    return <h1>Welcome, {session.user.email}</h1>;
}
