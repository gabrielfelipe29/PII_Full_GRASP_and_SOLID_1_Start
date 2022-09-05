//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Costo total= {GetProductionCost(this)}");
        }

        public double GetProductionCost(Recipe recipe)
        {
            /* 
            El calculo de la produccion se hace en la receta ya que es el que tiene acceso a toda 
            la información relevante, por lo tanto, es el expert 
            */
            double total = 0;
            foreach (Step step in recipe.steps)
            {
                // el tiempo fue considerado como si estuviera en minutos
                total = total + step.Input.UnitCost * step.Quantity + ((step.Time / 60) * step.Equipment.HourlyCost);

            }
            return total;
        }
    }
}