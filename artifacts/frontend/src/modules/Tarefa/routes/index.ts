import type { RouteRecordRaw } from 'vue-router'
import Listar from '../views/Listar.vue'
import Criar from '../views/Criar.vue'

export const routes: RouteRecordRaw[] = [
  {
    name: 'tarefa-home',
    path: 'home',
    component: Listar,
  },
  {
    name: 'tarefa-criar',
    path: 'criar/:id?',
    component: Criar,
  }
]