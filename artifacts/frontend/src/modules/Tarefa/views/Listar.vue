<script setup lang="ts">
import { ref, onBeforeMount } from 'vue'
import { useRouter } from 'vue-router'
import { useUiStore } from '@/stores/ui'
import {
  listarTarefa,
  excluirTarefas,
} from '../controllers/tarefa'
import type { Tarefa } from '../types/tarefa'



const ui = useUiStore()
const headers = [
    { value: 'titulo', title: 'titulo' },
    { value: 'descricao', title: 'descricao' },
    { value: 'data_vencimento', title: 'data_vencimento' }

]
const items = ref<Tarefa[]>([])

const carregarTarefas = async () => {
  const tarefa = await listarTarefa()
  items.value = tarefa
}

const router = useRouter()
const editarTarefa = (cls: Tarefa) => {
  router.push({ name: 'tarefa-criar', params: { id: cls.Id }})
}

const excluirtarefa = async (cls: Tarefa[]) => {
  const ids = cls.map((a) => a.Id)
  await excluirTarefas(ids)
  await carregarTarefas()
}

onBeforeMount(carregarTarefas)
</script>

<template>
  <data-table
    :headers="headers"
    :items="items"
    @editar="editarTarefa"
    @excluir="excluirtarefa"
  />
</template>