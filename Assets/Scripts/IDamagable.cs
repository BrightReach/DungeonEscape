using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable {

    int m_IHealth { get; set; }

    void Damage();

}
