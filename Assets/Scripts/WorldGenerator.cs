using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour
{
    // Значения публичных полей можно поменять прямо из редактора

    // Перетащите сюда объект Voxel со сцены
    // Используется для создания новых экземпляров
    public GameObject Voxel;

    // Определяем размер мира
    public float SizeX;
    public float SizeZ;
    public float SizeY;

    // Используется для инициализации
    void Start() {
        // Стартуем поток генерации мира
        StartCoroutine(SimpleGenerator());
    }

    // Метод Update вызывается единожды каждый фрейм
    void Update() {

    }

    public static void CloneAndPlace(Vector3 newPosition,
                                     GameObject originalGameobject) {
        // Клон
        GameObject clone = (GameObject)Instantiate(originalGameobject,
                                                   newPosition, Quaternion.identity);
        // Позиция
        clone.transform.position = newPosition;
        // Переименовываем
        clone.name = "Cube@" + clone.transform.position;
    }

    IEnumerator SimpleGenerator() {
        // В этом потоке мы будем создавать 50 кубов за один фрейм
        uint numberOfInstances = 0;
        uint instancesPerFrame = 50;

        for(int x = 1; x <= SizeX; x++) {
            for(int z = 1; x <= SizeZ; z++) {
                // Получаем случайную высоту
                float height = Random.Range(0, SizeY);
                for (int y = 0; y <= height; y++) {
                    // Расчитываем позицию для каждого блока
                    Vector3 newPosition = new Vector3(x, y, z);
                    // Вызываем метод, передавая ему новую позицию и экземпляр куба
                    CloneAndPlace(newPosition, Voxel);
                    // Инкрементируем numberOfInstances
                    numberOfInstances++;

                    // Если было достигнуто предельное количество экземпляров за фрейм
                    if(numberOfInstances == instancesPerFrame) {
                        // Сбрасываем numberOfInstances
                        numberOfInstances = 0;
                        // И ждем следующего фрейма
                        yield return new WaitForEndOfFrame();
                    }
                }
            }
        }
    }
}