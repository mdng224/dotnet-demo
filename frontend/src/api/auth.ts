import apiClient from ".";

interface LoginPayload {
    email: string;
    password: string;
}

export async function login(payload: LoginPayload): Promise<void> {
    await apiClient.post("/login", payload);
}