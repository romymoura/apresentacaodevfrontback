// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  ApiAuth: 'http://localhost:501/api/user/login',
  ApiAirplaneGetAll: 'http://localhost:501/api/Airplane/getall',
  ApiAirplaneCreate: 'http://localhost:501/api/Airplane/insert',
  ApiAirplaneDelete: 'http://localhost:501/api/Airplane/delete?id=',
  ApiAirplaneGet: 'http://localhost:501/api/Airplane/get'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
