<script setup lang="ts">
import { ref, computed, onBeforeMount } from 'vue'
import { useRoute } from 'vue-router'
import {
  criarTarefa,
  obterTarefa,
  atualizarTarefa
} from '../controllers/tarefa'
import { useUiStore } from '@/stores/ui'
import type { ValidationResultFunction } from '@/utils/regras'

const route = useRoute()

const modo = computed<'criar' | 'editar'>(() => {
  if (route.params.id) {
    return 'editar'
  }
  return 'criar'
})

const ui = useUiStore()

const id = ref('')
const titulo = ref('')
const descricao = ref('')
const data_vencimento = ref('')


const primeiraMaiuscula: ValidationResultFunction = (novoNome: string) => {
  if (/^[A-Z].*$/.test(novoNome)) {
    return true
  }
  return 'O nome deve começar com uma letra maiúscula'
}

const regrasNome = [primeiraMaiuscula]

const nomeValido = ref(false)

const updateNomeValido = (novoValor: boolean) => {
  nomeValido.value = novoValor
}

const descricao = ref('')

const criar = async () => {
  if (!nomeValido.value) {
    ui.exibirAlerta({
      text: 'Por favor, corrija os campos incorretos.',
      color: 'error'
    })
    return false
  }
  const sucesso = await criarTarefa({
    titulo: titulo.value,
    descricao: descricao.value,
    data_vencimento: data_vencimento.value

  })
  if (sucesso) {
    titulo.value = ''
    descricao.value = ''
    data_vencimento.value = ''

  }
  return true
}

const atualizar = async () => {
  if (!nomeValido.value) {
    ui.exibirAlerta({
      text: 'Por favor, corrija os campos incorretos.',
      color: 'error'
    })
    return false
  }

  const sucesso = await atualizarTarefa({
    Id: id.value,
    titulo: titulo.value,
    descricao: descricao.value,
    data_vencimento: data_vencimento.value

  })
  return true
}

const dispatchBotao = async () => {
  if (modo.value === 'criar') {
    return await criar()
  }
  return await atualizar()
}

onBeforeMount(async () => {
  if (modo.value === 'editar') {
    const routeId: string = Array.isArray(route.params.id) ? route.params.id[0] : route.params.id
    const cls = await obterTarefa(routeId)
    id.value = cls.Id
    titulo.value = cls.titulo
    descricao.value = cls.descricao
    data_vencimento.value = cls.data_vencimento

  }
})
</script>

<template>
  <card class="w-md">
<text-input
  class="w-full"
  placeholder="Titulo"
  v-model="titulo"
/>
<text-input
  class="w-full"
  placeholder="Descricao"
  v-model="descricao"
/>
<text-input
  class="w-full"
  placeholder="Data_vencimento"
  v-model="data_vencimento"
/>

    <div class="flex justify-end">
      <p-button
        @click="dispatchBotao"
      >
        {{ modo === 'criar' ? 'Registrar' : 'Atualizar' }}
      </p-button>
    </div>
  </card>
</template>