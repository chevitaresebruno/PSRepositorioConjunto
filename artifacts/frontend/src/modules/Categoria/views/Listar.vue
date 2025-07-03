<script setup lang="ts">
import { ref, onBeforeMount } from 'vue'
import { useRouter } from 'vue-router'
import { useUiStore } from '@/stores/ui'
import {
  listarCategoria,
  excluirCategorias,
} from '../controllers/categoria'
import type { Categoria } from '../types/categoria'



const ui = useUiStore()
const headers = [
    { value: 'nome', title: 'nome' }

]
const items = ref<Categoria[]>([])

const carregarCategorias = async () => {
  const categoria = await listarCategoria()
  items.value = categoria
}

const router = useRouter()
const editarCategoria = (cls: Categoria) => {
  router.push({ name: 'categoria-criar', params: { id: cls.Id }})
}

const excluircategoria = async (cls: Categoria[]) => {
  const ids = cls.map((a) => a.Id)
  await excluirCategorias(ids)
  await carregarCategorias()
}

onBeforeMount(carregarCategorias)
</script>

<template>
  <data-table
    :headers="headers"
    :items="items"
    @editar="editarCategoria"
    @excluir="excluircategoria"
  />
</template>