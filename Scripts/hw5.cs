using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using JetBrains.Annotations;
using UnityEngine;

public class hw5 : MonoBehaviour
    {
        void Start()
        {
            List<float> numbers = new List<float>();

            numbers.Add(92.4f);
            numbers.Add(2f);
            numbers.Add(211.6f);
            numbers.Add(65f);
            numbers.Add(903f);
            numbers.Add(1f);
            numbers.Add(0.654f);
            numbers.Add(23f);
            numbers.Add(182f);

            var numberArray = numbers.ToArray();
            int i = 0, count = 0;
            while (i != numberArray.Length)
            {
                if (numberArray[i] % 1 == 0)
                {
                    count++;
                }
                i++;
            }

            Debug.Log($"Целых чисел: {count}");
        }

        
    }
