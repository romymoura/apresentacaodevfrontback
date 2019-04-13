const proxy = [
    {
      context: '/api',
      target: 'http://localhost:501',
      pathRewrite: {'^/api' : ''}
    }
  ];
  module.exports = proxy;