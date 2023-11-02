export const apiBaseUrl = "https://localhost:44364/";

export const environment = {
    ssoSignOnUrl: apiBaseUrl + 'api/oidc/InitiateSingleSignOn',
    ssoSignOutUrl: apiBaseUrl + 'api/oidc/InitiateSingleSignOut'
};
