import superagentPromise from 'superagent-promise';
import _superagent from 'superagent';

const superagent = superagentPromise(_superagent, global.Promise);

const API_ROOT = 'https://turino-tdc-api-brazil.azurewebsites.net/v1';

const responseBody = res => res.body;

const requests = {
    del: (url, query) =>
      superagent.del(`${API_ROOT}${url}`).query(query).then(responseBody),
    get: url =>
      superagent.get(`${API_ROOT}${url}`).then(responseBody),
    put: (url, body) =>
      superagent.put(`${API_ROOT}${url}`, body).then(responseBody),
    post: (url, body) =>
      superagent.post(`${API_ROOT}${url}`, body).then(responseBody)
  };

export const Todo = {
  all: () => requests.get("/todo"),
  completed: () => requests.get("/todo/completed"),
  pending: () => requests.get("/todo/pending"),
  save: (todo) => requests.post("/todo", todo),
  remove: (id) => requests.del("/todo", { id } ),
  done: (id) => requests.put("/todo/done", { id })
};