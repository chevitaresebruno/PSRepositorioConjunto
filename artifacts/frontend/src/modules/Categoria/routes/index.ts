import type { RouteRecordRaw } from 'vue-router'
import Listar from '../views/Listar.vue'
import Criar from '../views/Criar.vue'

export const routes: RouteRecordRaw[] = [
  {
    name: 'categoria-home',
    path: 'home',
    component: Listar,
  },
  {
    name: 'categoria-criar',
    path: 'criar/:id?',
    component: Criar,
  }
]