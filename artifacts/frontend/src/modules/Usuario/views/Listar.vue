<script setup lang="ts">
import { ref, onBeforeMount } from 'vue'
import { useRouter } from 'vue-router'
import { useUiStore } from '@/stores/ui'
import {
  listarUsuario,
  excluirUsuarios,
} from '../controllers/usuario'
import type { Usuario } from '../types/usuario'



const ui = useUiStore()
const headers = [
    { value: 'nome', title: 'nome' },
    { value: '_email', title: '_email' },
    { value: 'senha', title: 'senha' }

]
const items = ref<Usuario[]>([])

const carregarUsuarios = async () => {
  const usuario = await listarUsuario()
  items.value = usuario
}

const router = useRouter()
const editarUsuario = (cls: Usuario) => {
  router.push({ name: 'usuario-criar', params: { id: cls.Id }})
}

const excluirusuario = async (cls: Usuario[]) => {
  const ids = cls.map((a) => a.Id)
  await excluirUsuarios(ids)
  await carregarUsuarios()
}

onBeforeMount(carregarUsuarios)
</script>

<template>
  <data-table
    :headers="headers"
    :items="items"
    @editar="editarUsuario"
    @excluir="excluirusuario"
  />
</template>