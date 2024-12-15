import type { UserObject, BackendJWT, BackendAccessJWT } from "next-auth";
import { v4 as uuidv4 } from "uuid";

var jwt = require("jsonwebtoken");

/**
 * Log in a user by sending a POST request to the backend using the supplied credentials.
 *
 * TODO: Implement the actual login functionality by sending a POST request to the backend
 *
 * @param email The email of the user
 * @param password The password of the user
 * @returns A BackendJWT response from the backend.
 */
export async function login(
  email: string,
  password: string
): Promise<Response> {
  console.debug("Logging in");

  if (!email || !password) {
    throw new Error("Email and password are required");
  }

  // Dummy data to simulate a successful login
  const response = await fetch("http://localhost:5202/api/auth/login", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ email, password }),
  });

  if (!response.ok) {
    throw new Error("Login failed");
  }

  return response; 
}

/**
 * Refresh the access token by sending a POST request to the backend using the supplied refresh token.
 *
 * TODO: Implement the actual refresh functionality by sending a POST request to the backend
 *
 * @param token The current refresh token
 * @returns A BackendAccessJWT response from the backend.
 */
export async function refresh(refreshToken: string): Promise<Response> {
  console.debug("Refreshing token");

  if (!refreshToken) {
    throw new Error("Refresh token is required");
  }

  const response = await fetch("http://localhost:5202/api/auth/refresh", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ refreshToken }),
  });

  if (!response.ok) {
    throw new Error("Refresh token failed");
  }

  return response;
}
