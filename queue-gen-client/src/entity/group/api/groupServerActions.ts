import { buildApiUrl } from "@/src/shared/lib/helpers/urlHelpers";

export const getUserGroupsAsync = async (token: string) => {
    const url = buildApiUrl(["me", "groups"]);

    const response = await fetch(url, {
        method: "GET",
        headers: {
            Authorization: `Bearer ${token}`,
        }
    })

    if (!response.ok) {
        throw new Error(`Failed to fetch groups: ${response.statusText}`);
      }
    
      return response.json();
};
