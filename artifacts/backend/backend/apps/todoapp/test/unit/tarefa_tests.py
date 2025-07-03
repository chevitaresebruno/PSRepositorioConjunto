import json
from rest_framework import status
from django.test import TestCase, Client
from django.urls import reverse
from todoapp.models import Tarefa
from todoapp.serializers import TarefaSerializer
from faker import Faker
import random

class TarefaTests(TestCase):
    def setUp(self):
        self.faker = Faker('pt_BR')
        self.client = Client()

        self.tarefa_1 = Tarefa.objects.create(titulo = self.faker.first_name(), descricao = self.faker.first_name(), data_vencimento = self.faker.date())
        self.tarefa_2 = Tarefa.objects.create(titulo = self.faker.first_name(), descricao = self.faker.first_name(), data_vencimento = self.faker.date())
        self.tarefa_3 = Tarefa.objects.create(titulo = self.faker.first_name(), descricao = self.faker.first_name(), data_vencimento = self.faker.date())

        self.valid_payload = {
            'titulo' : self.faker.first_name(),'descricao' : self.faker.first_name(),'data_vencimento' : self.faker.date()
        }
        self.invalid_payload = {
            'titulo' : self.faker.first_name(),'descricao' : self.faker.first_name(),'data_vencimento' : self.faker.date()
        }

    def test_valid_create(self):
        response = self.client.post(
            reverse('tarefa-api-list'),
            data=json.dumps(self.valid_payload),
            content_type='application/json'
        )
        self.assertEqual(response.status_code, status.HTTP_201_CREATED)

    def test_invalid_create(self):
        response = self.client.post(
            reverse('tarefa-api-list'),
            data=json.dumps(self.invalid_payload),
            content_type='application/json'
        )
        self.assertEqual(response.status_code, status.HTTP_400_BAD_REQUEST)

    def test_valid_upload(self):
        response = self.client.put(
            reverse('tarefa-detail',
            kwargs={'pk': self.tarefa_1.id}),
            data=json.dumps(self.valid_payload),
            content_type='application/json'
        )
        self.assertEqual(response.status_code, status.HTTP_200_OK)

    def test_invalid_upload(self):
        response = self.client.put(
            reverse('tarefa-detail',
            kwargs={'pk': self.tarefa_1.id}),
            data=json.dumps(self.invalid_payload),
            content_type='application/json'
        )
        self.assertEqual(response.status_code, status.HTTP_400_BAD_REQUEST)

    # retornando todos os elementos    
    def test_retrieve_all(self):
        response   = self.client.get(reverse('tarefa-api-list'))
        data       = Tarefa.objects.all()
        serializer = TarefaSerializer(data, context={'request': None}, many=True)
        # Aqui deve comparar todos os compos do objeto com serialização
        self.assertEqual(response.data, serializer.data)

        self.assertIsNotNone(response.data)
        self.assertEqual(response.status_code, status.HTTP_200_OK)

    # retornando um elemento
    def test_valid_get_element(self):
        response = self.client.get(reverse('tarefa-detail',kwargs={'pk': self.tarefa_1.id}))
        data = Tarefa.objects.get(pk=self.condicao_1.id)
        # Aqui deve comparar todos os campos do objeto com serialização
        self.assertEqual(str(data.uuid),response.data['uuid'])
        self.assertIsNotNone(response.data)
        self.assertEqual(response.status_code, status.HTTP_200_OK)

    # erro ao retornar um elemento invalido
    def test_invalid_get_element(self):
        response = self.client.get(reverse('tarefa-detail',kwargs={'pk': 666}))
        self.assertEqual(response.status_code, status.HTTP_404_NOT_FOUND)

    # Delete um elemento valido
    def test_valid_delete(self):
        response = self.client.delete(reverse('tarefa-detail',kwargs={'pk': self.tarefa_1.id}))
        self.assertEqual(response.status_code, status.HTTP_204_NO_CONTENT)

    # Delete um elemento valido
    def test_invalid_delete(self):
        response = self.client.delete(reverse('tarefa-detail',kwargs={'pk': 666}))
        self.assertEqual(response.status_code, status.HTTP_404_NOT_FOUND)
