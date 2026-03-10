window.cyberQuizAuth = {
    postJson: async (url, payload) => {
        const response = await fetch(url, {
            method: "POST",
            credentials: "include",
            headers: { "Content-Type": "application/json" },
            body: payload ? JSON.stringify(payload) : null
        });

        if (!response.ok) {
            const message = await response.text();
            throw new Error(message || response.statusText);
        }

        return true;
    }
};