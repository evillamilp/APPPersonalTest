const baseUrl = 'http://localhost:4200';

export const environment = {

  production: false,

  apiUrl: 'https://localhost:7107/',

  application: {

    baseUrl,

    name: 'TESTApplication',

    logoUrl: '',

  },

  oAuthConfig: {

    issuer: 'https://localhost:7107/',

    //redirectUri: baseUrl,

    clientId: 'TESTApplication',

    //responseType: 'code',

    scope: 'offline_access TESTApplication',

    //dummyClientSecret: '1q2w3e*',

    //requireHttps: true,

  },

  apis: {

    default: {

      url: 'https://localhost:7107/',

      rootNamespace: 'TESTApplication',

    },

  },

}