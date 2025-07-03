import { type RouteRecordRaw } from 'vue-router'

import { routes as usuarioRoute } from './Usuario'
import { routes as categoriaRoute } from './Categoria'
import { routes as tarefaRoute } from './Tarefa'


export const routes: RouteRecordRaw[] = [
  ...usuarioRoute,
  ...categoriaRoute,
  ...tarefaRoute,

]